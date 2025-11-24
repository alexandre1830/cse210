public class Customer
{
    private string _name;
    private Address _address; // Composition: Customer has an Address

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Accessor Properties (Getters)
    public string Name
    {
        get { return _name; }
    }

    public Address Address
    {
        get { return _address; }
    }

    // Method to check if the customer lives in the USA (delegates to Address)
    public bool IsInUSA()
    {
        return _address.IsUSA();
    }
}