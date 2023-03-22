namespace SocialMedia.Controllers.PackageController.DTO
{
    public class SubCategoryModel
    {
        public Guid CategoryId { get; set; }
        public string? SubCategory { get; set; }
        public string? Icon { get; set; }
    }
    public class CategoryFeatureMode
    {
        public Guid SubCategoryId { get; set; }
        public string Name { get; set; }
        public string? Icon { get; set; }
    }

}
