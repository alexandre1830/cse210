public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Method to check if the address is in the USA (case-insensitive)
    public bool IsUSA()
    {
        return _country.ToLower() == "usa";
    }

    // Method to format the full address for the shipping label
    public string GetFullAddress()
    {
        // Uses \n (newline) to format the address
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}