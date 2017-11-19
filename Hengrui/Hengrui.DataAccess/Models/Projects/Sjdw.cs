namespace Hengrui.DataAccess.Models.Projects
{
    public class Sjdw
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Address { get; set; }


        public string Sjzz { get; set; }

        public virtual Project Project { get; set; }
    }
}