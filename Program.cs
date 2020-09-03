using System;
using System.IO;
using System.Collections.Generic;
namespace PA1
{
    class Program
    {
        private static List<Post> postList = new List<Post>();
        //private static int id = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Loading.....");
            readFile();
            int input = -1;
            while(input != 4){
                Console.WriteLine("Big Al Goes Social!");
                Console.WriteLine("Select option:");
                Console.WriteLine("1: Show all Posts (ID, Post, Timestamp");
                Console.WriteLine("2: Add a post");
                Console.WriteLine("3: Delete a post by ID");
                Console.WriteLine("4: Quit");

                input = Convert.ToInt32(Console.ReadLine());
                if(input == 1){
                    Console.WriteLine("Showing all");
                    showAll();
                }
                else if(input == 2){
                    Console.WriteLine("Type Post Here:");
                    string text = Console.ReadLine();

                    addPost(text);

                }
                else if(input == 3){
                    Console.WriteLine("Type an ID to delete");
                    string temp = Console.ReadLine();
                    deletePost(Convert.ToInt32(temp));
                }
                else if(input == 4){
                    Console.WriteLine("Exiting");
                    return;
                }
            }
        }
        static void readFile(){
            try{
                StreamReader sr = File.OpenText("posts.txt");
                string line = sr.ReadLine();
                int id;
                string text;
                DateTime time;
                while(line != null){
                    Console.WriteLine(line);
                    var splitLine = line.Split('#');
                    id = int.Parse(splitLine[0]);
                    text = splitLine[1];
                    time = DateTime.Parse(splitLine[2]);
                    Post p = new Post(id,text,time);
                    postList.Add(p);
                    line = sr.ReadLine();
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Posts are not in valid format or posts,txt doesn't exist");
                Console.WriteLine("Creating posts.txt");
                StreamWriter sw = File.CreateText("posts.txt");
                sw.Close();
                //Console.WriteLine(e.ToString());
            }
        }
        static void showAll()
        {
        
            if(postList.Count == 0){
                Console.WriteLine("No Posts to Display");
            }
            else{
                foreach(var x in postList)
                {
                    Console.WriteLine(String.Concat(x.postId.ToString()," ",x.postText," ", x.timestamp.ToString()));
                }
            }
        }

        static void addPost(string text)
        {
            Post p = new Post(postList.Count+1,text,DateTime.Now);
            StreamWriter sw = new StreamWriter("posts.txt", true);
            postList.Add(p);
            sw.WriteLine(String.Concat(p.postId.ToString(),"#",text,"#", p.timestamp.ToString()));
            sw.Close();
            Console.WriteLine("Post added");
        }
        static void deletePost(int id)
        {
            
            try{
                postList.RemoveAt(id-1);
                Console.WriteLine("Removed!");
            }
            catch(Exception e){
                Console.WriteLine("Error: Id does not exist");
            }

        }
    }
}