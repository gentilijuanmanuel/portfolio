namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Testimonio")]
    public partial class Testimonio
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        [Required]
        [StringLength(50)]
        public string IP { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Comentario { get; set; }

        [Required]
        [StringLength(10)]
        public string Fecha { get; set; }

        public virtual Usuario Usuario { get; set; }

        //Methods

        public List<Testimonio> getAll(int usuario_id)
        {
            List<Testimonio> testimonios = new List<Testimonio>();

            using (var ctx = new ProjectContext())
            {
                testimonios = ctx.Testimonio.Where(x => x.Usuario_id == usuario_id)
                                              .ToList();
            }

            return testimonios;
        }

        public Testimonio getTestimony(int id)
        {
            var testimonio = new Testimonio();

            try
            {
                using (var ctx = new ProjectContext())
                {
                    testimonio = ctx.Testimonio.Where(x => x.id == id)
                                               .SingleOrDefault();

                }
            }
            catch (Exception E)
            {

                throw;
            }

            return testimonio;
        }

        public ResponseModel Save()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProjectContext())
                {
                    if (this.id > 0)
                    {
                        ctx.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(this).State = EntityState.Added;
                    }

                    ctx.SaveChanges();

                    rm.SetResponse(true);
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return rm;
        }


        public void Delete(int id)
        {
            try
            {
                using (var ctx = new ProjectContext())
                {
                    this.id = id;

                    ctx.Entry(this).State = EntityState.Deleted;

                    ctx.SaveChanges();
                }
            }
            catch (Exception E)
            {

                throw;
            }
        }
    }
}
