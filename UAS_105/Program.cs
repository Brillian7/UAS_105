using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_105
{
    class node
    {
        public int nobuku, judul;
        public string name, tahun;
        public node next;
    }
    class List
    {
        node START;
        public List()
        {
            START = null;
        }
        public void addnode() //menambahkan node dalam list
        {
            int nobuku, judul;
            string name, tahun;

            Console.Write("\nMasukkan nomor buku: ");
            nobuku = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Judul Buku: ");
            judul = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama pengarang: ");
            name = Convert.ToString(Console.ReadLine());
            Console.Write("\nMasukkan Tahun Terbit: ");
            tahun = Convert.ToString(Console.ReadLine());

            node newnode = new node();
            newnode.nobuku = nobuku;
            newnode.judul = judul;
            newnode.name = name;
            newnode.tahun = tahun;

            //jika node yang diinput adalah node pertama
            if (START == null || nobuku <= START.nobuku)
            {
                if((START != null) && (nobuku <= START.nobuku))
                {
                    Console.WriteLine("\nNomor buku tidak diterima karena sudah tersedia.\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            //mengalokasikan posisi node baru pada list
            node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nobuku >= current.nobuku))
            {
                if (nobuku == current.nobuku)
                {
                    Console.WriteLine("\nNomor buku tidak diterima karena sudah tersedia.\n");
                    return ;
                }
                previous = current;
                current = current.next;
            }


            newnode.next = current;
            previous.next = newnode;
            
        }
       
        public bool search(int nobuku, ref node previous,ref node current)
        {
            previous = START;
            current = START;

            while((current != null)&& (nobuku != current.nobuku))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }

        public void traverse() //traverses the list
        {
            if (listEmpty())
                Console.WriteLine("\nData Kosong\n");
            else
            {
                Console.WriteLine("\nData yang tersimpan: \n");
                node currentnode;
                for (currentnode = START; currentnode != null; currentnode = currentnode.next)
                    Console.WriteLine("\nNomor Buku: " + currentnode.nobuku + "\n" +
                        "Nomor Buku: " + currentnode.nobuku + "\n" +
                        "Judul Buku: " + currentnode.judul + "\n" +
                        "Nama Pengarang: " + currentnode.name + "\n" +
                        "Tahun Terbit: " + currentnode.tahun + "\n"
                        );
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu pilihan ");
                    Console.WriteLine("1. Masukkan Nomor Buku ");
                    Console.WriteLine("2. Mengurutkan Data ");
                    Console.WriteLine("3. Menampilkan Data ");
                    Console.WriteLine("4. Mencari data"); //Linear Search
                    Console.WriteLine("5. Exit ");
                    Console.Write("\nEnter your choice (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addnode();
                            }
                            break;
                        case '2':
                            {
                                Console.WriteLine("--");
                            }
                            break ;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nData Kosong.");
                                    break ;
                                }
                                node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan Nomor buku " + " yang akan dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                {
                                    Console.WriteLine("\nData ditemukan!");
                                    Console.WriteLine("========================================");
                                    Console.WriteLine("\nNomor Buku: " + current.nobuku);
                                    Console.WriteLine("\nJudul Buku: " + current.judul);
                                    Console.WriteLine("\nNama Pengarang: " + current.name);
                                    Console.WriteLine("\nTahun Terbit: " + current.judul);
                                    Console.WriteLine("=========================================");
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\n[Pilihan Salah]");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value entered.");
                }
            }
        }
    }
}


//2. bubble sort,insetion sort
// single linked list,doubly linked list
//3. PUSH and POP
//4. Element are inserted at the REAR end and delete from the FRONT end.
//5. a. 5
//   b. postorder traversal = -Kunjungi kiri node tersebut,
// => Jika kiri bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kiri tersebut.
// => Jika kiri kosong (NULL), lanjut ke langkah kedua.
// - Kunjungi kanan node tersebut,
// => Jika kanan bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kanan tersebut.
// => Jika kanan kosong (NULL), lanjut ke langkah ketiga.
// -Cetak isi (data) node yang sedang dikunjungi. Proses untuk node ini selesai, tuntaskan proses yang sama untuk node yang dikunjungi sebelumnya
