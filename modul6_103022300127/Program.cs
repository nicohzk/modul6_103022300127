﻿
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

class SayaTubeUser {
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;

    public SayaTubeUser(string a)
    {
        if (a == null || a.Length >= 100) throw new ArgumentException("Username Tidak Valid");
        this.Username = a;
        Random x = new Random();
        this.id = x.Next(10000, 99999);
        uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount() {
        int x = 0;
        for (int i = 0; i < uploadedVideos.Count; i++)
        {
            x += uploadedVideos[i].GetplayCount();
        }
        return x;
    }
    public void AddVideo(SayaTubeVideo o) {
        if (o == null || o.GetplayCount() >= int.MaxValue) throw new ArgumentException("UploadedVideos Tidak Valid");
        uploadedVideos.Add(o);
    }

    public void PrintAllPlaycount() {
        Console.WriteLine("Username: " + this.Username);
        int Count = 0;
        for (int i = 0; i < uploadedVideos.Count; i++) {

            Console.WriteLine("Video " + (i+1) + ": ");
            uploadedVideos[i].PrintVideoDetails();
            Count++;
            if (Count > 8)
            {
                throw new ArgumentException("Jumlah video maksimal yang di-print adalah 8");
            }

        }

    }
}

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playcount;

    public SayaTubeVideo(string a)
    {
        if (a == null || a.Length > 200) throw new ArgumentException("Judul tidak valid");

        this.title = a;
        Random x = new Random();
        id = x.Next(1, 99999);
        this.playcount = 0;
    }

    public void IncreaseVideoPlayCount(int x)
    {
        if (x <= 0 || x >= 25000000) throw new ArgumentException("Penambahan PlayCount Tidak Valid");
        try
        {
            checked 
            {
                this.playcount += x;
            }
        }
        catch(OverflowException e)
        {
            Console.WriteLine("Error: Play count melebihi batas maksimum integer");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("id :" + this.id);
        Console.WriteLine("title :" + this.title);
        Console.WriteLine("playcount :" + this.playcount);
    }
    public int GetplayCount() {
        return this.playcount;
    }
}
class system
{
    public static void Main()
    {
        
        SayaTubeUser x = new SayaTubeUser("Hizkia");
        SayaTubeVideo a = new SayaTubeVideo("Review Film 1 oleh Hizkia.");
        SayaTubeVideo b = new SayaTubeVideo("Review Film 2 oleh Hizkia.");
        SayaTubeVideo c = new SayaTubeVideo("Review Film 3 oleh Hizkia.");
        SayaTubeVideo d = new SayaTubeVideo("Review Film 4 oleh Hizkia.");
        SayaTubeVideo e = new SayaTubeVideo("Review Film 5 oleh Hizkia.");
        SayaTubeVideo f = new SayaTubeVideo("Review Film 6 oleh Hizkia.");
        SayaTubeVideo g = new SayaTubeVideo("Review Film 7 oleh Hizkia.");
        SayaTubeVideo h = new SayaTubeVideo("Review Film 8 oleh Hizkia.");
        SayaTubeVideo i = new SayaTubeVideo("Review Film 9 oleh Hizkia.");
        SayaTubeVideo j = new SayaTubeVideo("Review Film 10 oleh Hizkia.");

        x.AddVideo(a);
        x.AddVideo(b);
        x.AddVideo(c);
        x.AddVideo(d);
        x.AddVideo(e);
        x.AddVideo(f);
        x.AddVideo(g);
        x.AddVideo(h);
        x.AddVideo(i);
        x.AddVideo(j);

        for (int count = 0; count < 100; count++) {
            a.IncreaseVideoPlayCount(24000000);
        }
        a.PrintVideoDetails();

        x.PrintAllPlaycount();
        x.GetTotalVideoPlayCount();
    }
}