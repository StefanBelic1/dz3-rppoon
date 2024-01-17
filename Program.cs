public interface ITV
{
    void UseInterface();
}

public interface IDisplay
{
    void UseInterface();
}


public class SamsungTV : ITV
{
    public void UseInterface()
    {
        Console.WriteLine("Using Samsung TV");
    }
}


public class DellTV : ITV
{
    public void UseInterface()
    {
        Console.WriteLine("Using Dell TV");
    }
}


public class SamsungDisplay : IDisplay
{
    public void UseInterface()
    {
        Console.WriteLine("Using Samsung display");
    }
}


public class DellDisplay : IDisplay
{
    public void UseInterface()
    {
        Console.WriteLine("Using Dell display");
    }
}


public abstract class ElectronicsFactory
{
    public abstract ITV CreateTV();
    public abstract IDisplay CreateDisplay();
}


public class SamsungFactory : ElectronicsFactory
{
    public override ITV CreateTV()
    {
        return new SamsungTV();
    }

    public override IDisplay CreateDisplay()
    {
        return new SamsungDisplay();
    }
}

public class DellFactory : ElectronicsFactory
{
    public override ITV CreateTV()
    {
        return new DellTV();
    }

    public override IDisplay CreateDisplay()
    {
        return new DellDisplay();
    }
}


public class App
{
    private ITV samsungTV;
    private IDisplay dellDisplay;

    public App(ElectronicsFactory factory)
    {
        samsungTV = factory.CreateTV();
        dellDisplay = factory.CreateDisplay();
    }

    public void UseDevices()
    {
        samsungTV.UseInterface();
        dellDisplay.UseInterface();
    }
}

class Program
{
    static void Main()
    {
       
        ElectronicsFactory samsungFactory = new SamsungFactory();
        App samsungApp = new App(samsungFactory);
        samsungApp.UseDevices();

        ElectronicsFactory dellFactory = new DellFactory();
        App dellApp = new App(dellFactory);
        dellApp.UseDevices();
    }
}

/*  

SRP: Svaka klasa ima jednu odgovornost.
OCP: Kod je otvoren za proširenje, a zatvoren za modifikaciju, jer možemo dodavati nove tvornice bez mijenjanja postojećeg koda.
LSP: Sučelje ITV i IDisplay su zamjenjivi za njihove implementacije.
ISP: Sučelja su jasno definirana i ne sadrže nepotrebne metode.
DIP: Kod ovisi o apstrakcijama (ITV i IDisplay) umjesto o konkretnim implementacijama.

 */