using System;
using System.IO;

namespace ConsoleApp {

    public class SomeService {
        private FileSystemWatcher _watcher;
        public void OnStart() {
            _watcher = new FileSystemWatcher();
            _watcher.Path = @"c:\temp";
            _watcher.NotifyFilter = NotifyFilters.FileName;
            _watcher.Filter = "*.*";
            _watcher.Created += _watcher_Created;
            _watcher.EnableRaisingEvents = true;
        }

        private void _watcher_Created(object sender, FileSystemEventArgs e) {
            Console.WriteLine(e.Name);
        }
    }

    class Program {
        static void Main(string[] args) {
            var thing = new SomeService();
            thing.OnStart();
            Console.ReadLine();
        }
    }
}
