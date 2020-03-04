﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shiny.Push;
using Samples.Models;


namespace Samples.ShinyDelegates
{
    public class PushDelegate : IPushDelegate
    {
        readonly CoreDelegateServices services;
        readonly IPushManager pushManager;


        public PushDelegate(CoreDelegateServices services, IPushManager pushManager)
        {
            this.services = services;
            this.pushManager = pushManager;
        }

        public Task OnEntry(PushEntryArgs args)
        {
            throw new NotImplementedException();
        }

        public Task OnReceived(IDictionary<string, string> data)
            => this.Insert("NOTIFICATION RECEIVED");


        public Task OnTokenChanged(string token)
            => this.Insert("TOKEN CHANGE");


        Task Insert(string info) => this.services.Connection.InsertAsync(new PushEvent
        {
            Payload = info,
            Token = this.pushManager.CurrentRegistrationToken,
            Timestamp = DateTime.UtcNow
        });
    }
}
