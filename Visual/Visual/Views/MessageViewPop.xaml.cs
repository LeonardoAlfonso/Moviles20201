﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Visual.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageViewPop
    {
        MessageViewModel context = new MessageViewModel();
        public MessageViewPop()
        {
            InitializeComponent();
            BindingContext = context;
        }
    }
}