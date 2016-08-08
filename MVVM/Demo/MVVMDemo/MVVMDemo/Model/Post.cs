using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MVVMDemo.Model
{
    public class Post:ViewModelBase
    {
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged(()=>Id);
            }
        }

        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
