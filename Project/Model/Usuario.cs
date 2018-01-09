namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    using Helper;
    using System.Data.Entity.Validation;
    using System.Web;
    using System.IO;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Experiencia = new HashSet<Experiencia>();
            Habilidad = new HashSet<Habilidad>();
            Testimonio = new HashSet<Testimonio>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        [Column(TypeName = "text")]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Ciudad { get; set; }

        public int? Pais_id { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        [StringLength(100)]
        public string Twitter { get; set; }

        [StringLength(100)]
        public string YouTube { get; set; }

        [StringLength(50)]
        public string Foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experiencia> Experiencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habilidad> Habilidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Testimonio> Testimonio { get; set; }

        public ResponseModel Acceder(string email, string password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProjectContext())
                {
                    password = HashHelper.MD5(password);
                    var usuario = ctx.Usuario.Where(x => x.Email == email)
                                             .Where(x => x.Password == password)
                                             .SingleOrDefault();

                    if(usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.id.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Correo o contraseña incorrectos.");
                    }
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return rm;
        }

        public Usuario getUser(int id)
        {
            var usuario = new Usuario();

            try
            {
                using (var ctx = new ProjectContext())
                {
                    usuario = ctx.Usuario.Where(x => x.id == id)
                                         .SingleOrDefault();

                }
            }
            catch (Exception E)
            {

                throw;
            }

            return usuario;
        }

        public ResponseModel Save(HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProjectContext())
                {
                    ctx.Configuration.ValidateOnSaveEnabled = false;

                    var eUser = ctx.Entry(this);
                    eUser.State = EntityState.Modified;

                    //validación de la foto del lado de EF
                    if (foto != null)
                    {
                        //nombre del archivo con la fecha, para que no se repita nunca.
                        string file = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(foto.FileName);

                        //ruta en la que lo vamos a guardar
                        foto.SaveAs(HttpContext.Current.Server.MapPath("~/uploads/" + file));

                        // en nuestro modelo, el nombre del archivo
                        this.Foto = file;
                    }
                    else
                    {
                        eUser.Property(x => x.Foto).IsModified = false;
                    }

                    //validación del password del usuario del lado de EF
                    if (this.Password == null)
                    {
                        eUser.Property(x => x.Password).IsModified = false;
                    }
                    else
                    {
                        this.Password = HashHelper.MD5(this.Password);
                    }

                    ctx.SaveChanges();

                    rm.SetResponse(true);
                }
            }
            catch (DbEntityValidationException E)
            {
                throw;
            }
            catch (Exception E)
            {

                throw;
            }

            return rm;
        }
    }
}
