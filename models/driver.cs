
namespace ConsoleF1.models;

public class Driver {

    private int IdDriver;

    private string fullname;

    private string number;

    public Driver( int IDDriver, string fullname, string number ) {
        this.IdDriver = IDDriver;
        this.fullname = fullname;
        this.number = number;
    }

    public int IDDriver
    {
        get { return IdDriver; } 
        set { IdDriver = value; }
    }

    public string FullName
    {
        get { return fullname; } 
        set { fullname = value; }
    }

    public string Number
    {
        get { return number; }
        set { number = value; }
    }

}