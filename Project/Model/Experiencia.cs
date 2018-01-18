namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("Experiencia")]
    public partial class Experiencia
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        public byte Tipo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(10)]
        public string Desde { get; set; }

        [Required]
        [StringLength(10)]
        public string Hasta { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        public virtual Usuario Usuario { get; set; }


        //Methods

        public List<Experiencia> getAll(int tipo, int usuario_id)
        {
            List<Experiencia> experiencias = new List<Experiencia>();

            using (var ctx = new ProjectContext())
            {
                experiencias = ctx.Experiencia.Where(x => x.Tipo == tipo && x.Usuario_id == usuario_id)
                                              .ToList();
            }

            return experiencias;
        }

        public Experiencia getExperience(int id)
        {
            var experiencia = new Experiencia();

            try
            {
                using (var ctx = new ProjectContext())
                {
                    experiencia = ctx.Experiencia.Where(x => x.id == id)
                                                 .SingleOrDefault();

                }
            }
            catch (Exception E)
            {

                throw;
            }

            return experiencia;
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

        //public ResponseModel Delete(int id)
        //{
        //    var rm = new ResponseModel();

        //    try
        //    {
        //        using (var ctx = new ProjectContext())
        //        {
        //            this.id = id;

        //            ctx.Entry(this).State = EntityState.Deleted;

        //            ctx.SaveChanges();

        //            rm.SetResponse(true);
        //        }
        //    }
        //    catch (Exception E)
        //    {

        //        throw;
        //    }

        //    return rm;
        //}

        public void Delete(int id, byte tipo)
        {
            try
            {
                using (var ctx = new ProjectContext())
                {
                    this.id = id;
                    this.Tipo = tipo;

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
