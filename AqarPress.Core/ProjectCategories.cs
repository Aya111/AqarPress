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

        [Description("Residential&Commercial")]
        ResidentialAndCommercial = 407,

        [Description("Residential&Admin")]
        ResidentialAndAmin = 408,

        [Description("Commercial&Admin")]
        CommercialAndAdmin = 409,

        [Description("Commercial&Medical")]
        CommercialAndMedical = 410


    }
}