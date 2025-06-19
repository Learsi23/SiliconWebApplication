

using SiliconWebApplication.ViewModels.Courses;

namespace SiliconWebApplication.ViewModels.Account
{
    public class AccountDetailsViewModel
    {
        public ProfileInfoViewModel ProfileInfo { get; set; } = null!;
        public BasicInfoViewModel BasicInfo { get; set; } = null!;
        public AddressViewModel AddressModel { get; set; } = null!;
        public AccountSecurityViewModel Accountsecurity { get; set; } = null!;
        public List<SavedCourseViewModel> SavedCourses { get; set; } = [];
    

    }
}
