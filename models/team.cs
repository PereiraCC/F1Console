using ConsoleF1.models;

namespace ConsoleF1.models;

public class Team {

    private int IdTeam;

    private string name;

    private string fullname;

    private string chasis;

    private string motor;

    private List<Driver> drivers;

    public Team( int IDTeam, string name, string fullname, string chasis, string motor, List<Driver> drivers) {
        this.IdTeam = IDTeam;
        this.name = name;
        this.fullname = fullname;
        this.chasis = chasis;
        this.motor = motor;
        this.drivers = drivers;
    }

    public int IDTeam
    {
        get { return IdTeam; } 
        set { IdTeam = value; }
    }

    public string Name
    {
        get { return name; } 
        set { name = value; }
    }

    public string FullName
    {
        get { return fullname; } 
        set { fullname = value; }
    }

    public string Chasis
    {
        get { return chasis; } 
        set { chasis = value; }
    }

    public string Motor
    {
        get { return motor; } 
        set { motor = value; }
    }

    public List<Driver> Drivers
    {
        get { return drivers; } 
        set { drivers = value; }
    }

}