namespace LibeyTechnicalTestDomain.ProvinceAggregate.Domain
{
    public class Province
    {
        public string ProvinceCode { get; set; }
        public string ProvinceDescription { get; set; }
        public string RegionCode { get; set; }

        public Province(string provinceCode, string provinceDescription, string regionCode)
        {
            ProvinceCode= provinceCode;
            ProvinceDescription= provinceDescription;
            RegionCode= regionCode;
        }
    }
}
