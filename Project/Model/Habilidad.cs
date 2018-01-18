namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Habilidad")]
    public partial class Habilidad
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int Dominio { get; set; }

        public virtual Usuario Usuario { get; set; }

        //Methods

        public List<Habilidad> getAll(int usuario_id)
        {
            List<Habilidad> habilidades = new List<Habilidad>();

            using (var ctx = new ProjectContext())
            {
                habilidades = ctx.Habilidad.Where(x => x.Usuario_id == usuario_id)
                                              .ToList();
            }

            return habilidades;
        }

        public Habilidad getHability(int id)
        {
            var habilidad = new Habilidad();

            try
            {
                using (var ctx = new ProjectContext())
                {
                    habilidad = ctx.Habilidad.Where(x => x.id == id)
                                             .SingleOrDefault();

                }
            }
            catch (Exception E)
            {

                throw;
            }

            return habilidad;
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
