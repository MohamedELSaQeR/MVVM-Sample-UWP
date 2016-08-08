using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMDemo.Model;
using Newtonsoft.Json;

namespace MVVMDemo.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        public MainViewModel()
        {
            Posts = new ObservableCollection<Post>();
        }
        public void GetPosts()
        {
            for (int i = 0; i < 5; i++)
            {
                var post = new Post();
                post.Id = i;
                post.UserId = 2;
                post.Title = "title" + i;
                post.Body = "This is a Body";
                Posts.Add(post);
            }
            
        }
        public async Task GetComments()
        {
            var client = new HttpClient();
            var url = new Uri("http://jsonplaceholder.typicode.com/comments");
            var responseMessage = await client.GetAsync(url);
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<List<Post>>(responseString);
            Posts = new ObservableCollection<Post>(deserializedObject);
        }
        public ObservableCollection<Post> Posts { get; set; }

        private RelayCommand _myCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand MyCommand
        {
            get
            {
                return _myCommand
                    ?? (_myCommand = new RelayCommand(async () =>
                    {
                        MessageDialog hello = new MessageDialog("Welcome to Commands");
                        await hello.ShowAsync();
                    }));
            }
        }
    }
}
