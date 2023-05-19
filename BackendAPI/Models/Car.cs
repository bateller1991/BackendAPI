namespace BackendAPI.Models
{
    public class Car
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public int BodyStyleID { get; set; }
        public BodyStyle BodyStyle { get; set; }
    }
}
