using System;
using System.Runtime.CompilerServices;

public class Adress
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Adress(string street, string city, string stateOrProvince, string country)
    {
        _city = city;
        _country = country;
        _stateOrProvince = stateOrProvince;
        _street = street;
    }
    public bool LiveInUSA()
    {
        return _country == "USA";

    }

    public string Display()
    {
        return $"{_street}\n {_city}, {_stateOrProvince}\n {_country}";
    }
}