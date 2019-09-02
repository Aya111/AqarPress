using System.ComponentModel;

namespace AqarPress.Core
{
    public enum ProjectCategories
    {
        Residential = 400,
        Admin = 402,
        Complex = 403,
        Medical = 404,
        Commercial = 406,

        [Description("Office&Retail")]
        OfficeAndRetail = 407,

        [Description("Residential&Commercial")]
        ResidentialAndCommercial = 408

    }
}