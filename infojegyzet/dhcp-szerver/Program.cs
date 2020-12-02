using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    static List<string> excluded = new List<string>();
    static List<Allokacio> reserved = new List<Allokacio>();
    static List<Allokacio> dhcp = new List<Allokacio>();
    static List<Muvelet> test = new List<Muvelet>();

    static void Main(string[] args)
    {
        #region Beolvasas
        // 1. feladat
        var excludedBeolvasott = File.ReadAllLines(@"c:\temp\excluded.csv");
        var reservedBeolvasott = File.ReadAllLines(@"c:\temp\reserved.csv");
        var dhcpBeolvasott = File.ReadAllLines(@"c:\temp\dhcp.csv");
        var testBeolvasott = File.ReadAllLines(@"c:\temp\test.csv");

        foreach (var item in excludedBeolvasott)
        {
            excluded.Add(item);
        }

        foreach (var item in reservedBeolvasott)
        {
            var allokacio = new Allokacio(item);
            reserved.Add(allokacio);
        }

        foreach (var item in dhcpBeolvasott)
        {
            var allokacio = new Allokacio(item);
            dhcp.Add(allokacio);
        }

        foreach (var item in testBeolvasott)
        {
            var muvelet = new Muvelet(item);
            test.Add(muvelet);
        }
        #endregion

        // 2. feladat
        foreach (var muvelet in test)
        {
            if (muvelet.Operacio == "request")
            {
                var letezoKapcsolat = KiVanOsztvaAcim(muvelet.Cim);
                if (letezoKapcsolat)
                {
                    break;
                }
                else
                {
                    var fenntartottCim = FenntartottaMacCim(muvelet.Cim);
                    if (fenntartottCim)
                    {
                        var biztosLetezik = KiVanOsztvaAcim(muvelet.Cim);
                        if (biztosLetezik)
                        {
                            break;
                        }
                        else
                        {
                            var allokacio = reserved.SingleOrDefault(x => x.MAC == muvelet.Cim);
                            CimTarolasaASzerveren(allokacio);
                        }
                    }
                    else
                    {
                        const string prefix = "192.168.10.";
                        var kezdoIp = 99;
                        string ipcim = "";
                        do
                        {
                            kezdoIp += 1;
                            if (kezdoIp > 199)
                            {
                                throw new Exception("Az IP cím vége túllépte a 199-et.");
                            }

                            ipcim = $"{prefix}{kezdoIp}";
                        } while (!(SzabadAzIPcim(ipcim) && !TiltottAzIpCim(ipcim) && !FenntartottAzIpCim(ipcim)));

                        var allokacio = new Allokacio(muvelet.Cim, ipcim);
                        CimTarolasaASzerveren(allokacio);
                    }
                }
            }
            else
            {
                Release(muvelet.Cim);
            }
        }

        // 3. feladat
        List<string> eredmeny = new List<string>();
        foreach (var item in dhcp)
        {
            var csv = $"{item.MAC};{item.IPcim}";
            eredmeny.Add(csv);
        }

        File.WriteAllLines(@"c:\temp\dhcp_kesz.csv", eredmeny);

        Console.ReadLine();
    }

    static void Release(string ipcim)
    {
        var allokacio = dhcp.SingleOrDefault(x => x.IPcim == ipcim);
        if (allokacio != null)
        {
            dhcp.Remove(allokacio);
        }
    }

    static bool KiVanOsztvaAcim(string mac)
    {
        var kiosztas = dhcp.SingleOrDefault(x => x.MAC == mac);
        return kiosztas != null;
    }

    static bool FenntartottaMacCim(string mac)
    {
        var kiosztas = reserved.SingleOrDefault(x => x.MAC == mac);
        return kiosztas != null;
    }
    static bool FenntartottAzIpCim(string ip)
    {
        var kiosztas = reserved.SingleOrDefault(x => x.IPcim == ip);
        return kiosztas != null;
    }

    static void CimTarolasaASzerveren(Allokacio allokacio)
    {
        dhcp.Add(allokacio);
    }

    static bool SzabadAzIPcim(string ip)
    {
        var talalat = dhcp.SingleOrDefault(x => x.IPcim == ip);

        return talalat == null;
    }

    static bool TiltottAzIpCim(string ip)
    {
        var talalat = excluded.SingleOrDefault(x => x == ip);

        return talalat != null;
    }

    class Allokacio
    {
        public string MAC { get; set; }
        public string IPcim { get; set; }

        public Allokacio(string sor)
        {
            var a = sor.Split(';');
            MAC = a[0];
            IPcim = a[1];
        }

        public Allokacio(string mac, string ipCim)
        {
            MAC = mac;
            IPcim = ipCim;
        }
    }

    class Muvelet
    {
        public string Operacio { get; set; }
        public string Cim { get; set; }

        public Muvelet(string sor)
        {
            var a = sor.Split(';');
            Operacio = a[0];
            Cim = a[1];
        }
    }
}
