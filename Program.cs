using System;
using System.Collections.Generic;

class DataRekening
{
    public string Nama { get; set; }
    public double NoRek { get; set; }
    public double Saldo { get; set; }

    public DataRekening(string nama, double norek, double saldo)
    {
        Nama = nama;
        NoRek = norek;
        Saldo = saldo;
    }

    public void TampilkanData()
    {
        Console.WriteLine($"Nama: {Nama}, No Rekening: {NoRek}, Saldo: {Saldo:C}");
    }
}

class Program
{
    static List<DataRekening> nasabahList = new List<DataRekening>();

    static void Main()
    {
        // Data awal
        nasabahList.Add(new DataRekening("Faiz", 1111, 500000));
        nasabahList.Add(new DataRekening("Mita", 2222, 750000));

        int pilihan;
        do
        {
            Console.WriteLine("\n=== Welcome to Bank Pelita ===");
            Console.WriteLine("1. Data Rekening");
            Console.WriteLine("2. Setor Tunai");
            Console.WriteLine("3. Penarikan Dana");
            Console.WriteLine("4. Transfer Antar Rekening");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu (1-5) (ex: 2): ");
            pilihan = int.Parse(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    TampilkanSemuaRekening();
                    break;
                case 2:
                    SetorTunai();
                    break;
                case 3:
                    TarikTunai();
                    break;
                case 4:
                    Transfer();
                    break;
                case 5:
                    Console.WriteLine("Terima kasih telah menggunakan layanan Bank Pelita.");
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }
        } while (pilihan != 5);
    }

    static DataRekening CariRekening(double norek)
    {
        return nasabahList.Find(n => n.NoRek == norek);
    }

    static void TampilkanSemuaRekening()
    {
        Console.WriteLine("\nData Semua Rekening Nasabah:");
        foreach (var nasabah in nasabahList)
        {
            nasabah.TampilkanData();
        }
    }

    static void SetorTunai()
    {
        Console.Write("Masukkan No Rekening: ");
        double norek = double.Parse(Console.ReadLine());
        DataRekening akun = CariRekening(norek);
        if (akun != null)
        {
            Console.Write("Masukkan jumlah setoran: ");
            double jumlah = double.Parse(Console.ReadLine());
            if (jumlah > 0)
            {
                akun.Saldo += jumlah;
                Console.WriteLine("Setoran berhasil. Saldo baru: " + akun.Saldo);
            }
            else
            {
                Console.WriteLine("Jumlah tidak valid.");
            }
        }
        else
        {
            Console.WriteLine("Rekening tidak ditemukan.");
        }
    }

    static void TarikTunai()
    {
        Console.Write("Masukkan No Rekening: ");
        double norek = double.Parse(Console.ReadLine());
        DataRekening akun = CariRekening(norek);
        if (akun != null)
        {
            Console.Write("Masukkan jumlah penarikan: ");
            double jumlah = double.Parse(Console.ReadLine());
            if (jumlah > 0 && jumlah <= akun.Saldo)
            {
                akun.Saldo -= jumlah;
                Console.WriteLine("Penarikan berhasil. Saldo baru: " + akun.Saldo);
            }
            else
            {
                Console.WriteLine("Saldo tidak cukup atau jumlah tidak valid.");
            }
        }
        else
        {
            Console.WriteLine("Rekening tidak ditemukan.");
        }
    }

    static void Transfer()
    {
        Console.Write("Masukkan No Rekening Pengirim: ");
        double norekPengirim = double.Parse(Console.ReadLine());
        DataRekening pengirim = CariRekening(norekPengirim);

        if (pengirim != null)
        {
            Console.Write("Masukkan No Rekening Penerima: ");
            double norekPenerima = double.Parse(Console.ReadLine());
            DataRekening penerima = CariRekening(norekPenerima);

            if (penerima != null)
            {
                Console.Write("Masukkan jumlah transfer: ");
                double jumlah = double.Parse(Console.ReadLine());

                if (jumlah > 0 && jumlah <= pengirim.Saldo)
                {
                    pengirim.Saldo -= jumlah;
                    penerima.Saldo += jumlah;
                    Console.WriteLine("Transfer berhasil.");
                }
                else
                {
                    Console.WriteLine("Saldo tidak cukup atau jumlah tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("Rekening penerima tidak ditemukan.");
            }
        }
        else
        {
            Console.WriteLine("Rekening pengirim tidak ditemukan.");
        }
    }
}
