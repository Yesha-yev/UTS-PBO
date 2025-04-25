using System;

class DataRekening
{
    public string Nama;
    public double NoRek;
    public double Saldo;

    public DataRekening(string nama,double norek,double saldo)
    {
        Nama = nama;
        NoRek = norek;
        Saldo = saldo;
    }
    public virtual void Tampilan()
    {
        Console.WriteLine($"Data Nasabah");
        Console.WriteLine($"Nama {Nama} No Rek {NoRek} Saldo {Saldo}");
    }
}
class PenarikanDana : DataRekening
{
    public double nilai;
    public PenarikanDana(string nama, double norek, double saldo,double nil) : base(nama, norek, saldo)
    {
        nilai = nil;
    }
    public double GetSaldo()
    {
        return Saldo;
    }
    public void SetSaldo()
    {
        if (nilai < Saldo)
        {
            Saldo -= nilai;
        }
        else
        {
            Console.WriteLine("Saldo Tidak cukup");
        }
    }
    public override void Tampilan()
    {
        Console.WriteLine(SetSaldo); 
    }
}


class SetorTunai : DataRekening
{
    public double masukan;
    public SetorTunai(string nama, double norek, double saldo,double masuk) : base(nama, norek, saldo)
    {
        masukan = masuk;
    }
    public double DapatSaldo()
    {
        return Saldo;
    }
    public void AturSaldo()
    {
        if (masukan != 0)
        {
            Saldo += masukan;
        }
        else
        {
            Console.WriteLine("Setoran tidak boleh 0 atau kosong");
        }
    }
    //public void Nilaiyyy()
    //{
    //    Console.Write("Masukkan ");
    //    string masuk = Console.ReadLine();
    //    int masukan = int.Parse(masuk);
    //}
    public override void Tampilan()
    {
        Console.WriteLine(AturSaldo);
    }
}

class Transfer : DataRekening
{
    public double SaldoTem;
    public double jumlah;
    public Transfer(string nama,double norek,double saldo,double saldotem, double jum) : base(nama, norek, saldo)
    {
        SaldoTem = saldotem;
        jumlah = jum;
    }
    public double DapTrans()
    {
        return Saldo;
    }
    public void AtSal()
    {
        if (jumlah < Saldo)
        {
            
            Saldo -= jumlah;
            SaldoTem += jumlah;
        }
        else
        {
            Console.WriteLine("Jumlah melebihi saldo");
        }

    }
    public override void Tampilan()
    {
        Console.WriteLine(AtSal);
    }
}

class Program
{
    static void Main()
    {
        DataRekening darek = new DataRekening("mama", 12345678, 345678900);
        SetorTunai setor = new SetorTunai("apalah", 43729208, 100000, 300000);
        PenarikanDana pendan = new PenarikanDana("baba", 9876543, 3600000,100000);
        Transfer transfer = new Transfer("aku", 85345678, 1000000, 200000,100000);

        
        darek.Tampilan();
        pendan.Tampilan();
        transfer.Tampilan();
        setor.Tampilan();
    }
}