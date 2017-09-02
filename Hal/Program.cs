using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Hal
{
    public static class Program
    {
        public static string StartupPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string ProjectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(StartupPath).ToString()).ToString()).ToString() + "\\";
        public static ACP ACP = new ACP();
        public static Editor Editor = new Editor();

        private static void Main(string[] args) {
            foreach (string input in args) {
                Console.WriteLine(input);
            }
            System.Windows.Forms.Application.EnableVisualStyles();
            ACP.Show();

            while (true) {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public static void InterpretCommand(string input) {
            switch (input.ToLower()) {
                case "compile":
                    System.Diagnostics.Process.Start("Compiler.bat");
                    Environment.Exit(0);
                    break;
                case "test":
                    Test.MainMethod();
                    break;
            }

            string[] args = input.Split(' ');
            if (input.ToLower().StartsWith("edit")) {
                if (args.Length > 1) {
                    if (File.Exists(ProjectPath + args[1])) {
                        string[] code = File.ReadAllLines(ProjectPath + args[1]);
                        Editor.LoadCode(ProjectPath + args[1], code);
                        Editor.Show();
                    }
                }
            } else if (input.ToLower().StartsWith("create")) {
                if (args.Length > 1) {
                    if (!File.Exists(ProjectPath + args[1])) {
                        File.Create(ProjectPath + args[1]);
                        var p = new Microsoft.Build.Evaluation.Project(ProjectPath + "Hal.csproj");
                        p.AddItem("Compile", ProjectPath + args[1]);
                        p.Save();
                    }
                }
            } else if (input.ToLower().StartsWith("remove")) {
                if (args.Length > 1) {
                    if (File.Exists(ProjectPath + args[1])) {
                        List<string> csproj = new List<string>(File.ReadAllLines(ProjectPath + "Hal.csproj"));

                        string line = "<Compile Include=\"" + ProjectPath + args[1] + "\" />";
                        for (int i = 0; i < csproj.Count; i++) {
                            
                            if (csproj[i].Contains(line)) {
                                csproj.RemoveAt(i);
                            }
                        }

                        File.Delete(ProjectPath + args[1]);

                        File.WriteAllLines(ProjectPath + "Hal.csproj", csproj.ToArray());
                    }
                }
            }
        }

        public static void Write(string input) {
            Console.WriteLine(input);
        }
    }
}



















