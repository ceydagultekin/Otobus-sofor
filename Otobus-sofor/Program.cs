using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otobus_sofor
{
        class Program
        {
            static void Main(string[] args)
            {

                LinkedList otobus_saatleri = new LinkedList();
                otobus_saatleri.push("14.00");
                otobus_saatleri.push("13.00");
                otobus_saatleri.push("10.00");
                otobus_saatleri.append("15.00");
                otobus_saatleri.InsertAfter(otobus_saatleri.head, "11.00");
                otobus_saatleri.append("16.00");
                otobus_saatleri.InsertAfter(otobus_saatleri.head.next, "12.00");

                LinkedList sofor_adları = new LinkedList();
                sofor_adları.push("Ali Bey");
                sofor_adları.append("Mehmet Bey");
                sofor_adları.push("Ahmet Bey");
                otobus_saatleri.InsertAfter(sofor_adları.head, "Yılmaz Bey");
                otobus_saatleri.InsertAfter(sofor_adları.head.next, "Yavuz Bey");
                sofor_adları.append("Osman Bey");
                sofor_adları.append("Mustafa Bey");

                Console.WriteLine("202013709001 S.CEYDA GÜLTEKİN VERİ YAPILARI VE ALGORİTMALAR FİNAL PROJESİ");

                Console.WriteLine("Güzergahı şehir içi olan otobüsün kalkış saatleri:" + "\n");
                otobus_saatleri.printList();
                Console.WriteLine("Sırasıyla şoförlerin listesi:" + "\n");
                sofor_adları.printList();

                //Gün içinde 12.30 arabasının kaza yaptığını farz edelim.
                //O arabayı ve şoförünü listeden çıkarmamız ve 12.30-13.30 arasına yeni bir araba ve şoför eklememiz gerekir.

                otobus_saatleri.DeleteNode(2);
                sofor_adları.DeleteNode(2);
                Console.WriteLine(" \n");
                otobus_saatleri.InsertAfter(otobus_saatleri.head.next, "12.30");
                sofor_adları.InsertAfter(sofor_adları.head.next, "Orhan Bey");
                Console.WriteLine("Kaza yapıldıktan sonraki otobüs saatleri listesi :" + "\n");
                otobus_saatleri.printList();
                Console.WriteLine("Kaza yapıldıktan sonraki şoför listesi:" + "\n");
                sofor_adları.printList();

                //Bir vatandaşın belediyeyi arayıp öğlen 12.00 'da otobüs kalkıp kalkmayacağını sorduğunu var sayalım.
                Console.WriteLine("\n");
                if (otobus_saatleri.Search(otobus_saatleri.head, "12.00"))
                    Console.WriteLine("12.00 'da kalkan otobüs mevcuttur.");
                else
                    Console.WriteLine("Saat 12.00 otobüsü bugün için mevcut değildir.");

                Console.ReadKey();
            }
        }
        public class Node
        {
            public string data;
            public Node next;
            public Node(string d)
            {
                data = d;
                next = null;
            }
        }
        public class LinkedList
        {

            public Node head;
            public int getCount() // listenin uzunluğunu hesaplatmak için kullandığım metot
            {
                Node temp = head;
                int count = 0;
                while (temp != null)
                {
                    count++;
                    temp = temp.next;
                }
                return count;
            }
            public void push(string new_data) // ön tarafa düğüm eklemek için kullandığım metot 
            {
                Node new_node = new Node(new_data);

                new_node.next = head;

                head = new_node;
            }
            public void InsertAfter(Node prev_node, string new_data)// araya düğüm eklemek için kullandığım metot
            {
                if (prev_node == null)
                {
                    Console.WriteLine("the given previous node cannot be null");

                    return;
                }
                Node new_node = new Node(new_data);

                new_node.next = prev_node.next;

                prev_node.next = new_node;
            }
            public bool Search(Node head, string wanted)// listede düğüm arama işlemi için kullandığım metot
            {
                Node current = head;
                while (current != null)
                {
                    if (current.data == wanted)
                        return true;

                    current = current.next;
                }
                return false;
            }
            static string GetNodeth(Node head, int n) // N.düğümü almak için kullandığım metot
            {
                if (head == null)
                {
                    return null;
                }
                int count = 0;

                if (count == n)
                {
                    return head.data;
                }
                return GetNodeth(head.next, n - 1);
            }

            public void append(string new_data)// listenin sonuna düğüm eklemek için kullandığım metot
            {
                Node new_node = new Node(new_data);
                if (head == null)
                {
                    head = new Node(new_data);
                    return;
                }


                new_node.next = null;
                Node last = head;
                while (last.next != null)
                    last = last.next;

                last.next = new_node;
                return;
            }
            public void DeleteNode(int position)// belirli bir düğümü silmek için kullandığım metot
            {
                if (head == null)
                    return;
                Node temp = head;

                if (position == 0)
                {
                    head = temp.next;
                    return;
                }
                for (int i = 0; temp != null && i < position - 1; i++)
                {
                    temp = temp.next;
                }
                if (temp == null || temp.next == null)
                    return;

                Node next = temp.next.next;

                temp.next = next;

            }
            public void printList() // listeyi yazdırma işlemi
            {
                Node tempnode = head;
                while (tempnode != null)
                {
                    Console.WriteLine(tempnode.data + "");
                    tempnode = tempnode.next;
                }
            }

        }
 }
    

