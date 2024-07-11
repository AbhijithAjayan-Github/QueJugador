using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueJugadorApp.Models.Entity
{
    public class Player
    {
        // Unique Id
      public Guid Id {get;set;}   
      public string PlayerName {get;set;}
      public string PlayerAddress{get;set;}
      public string PlayerMail {get;set;}
      public string playerPhone {get;set;}
      public string PlayerPosition {get;set;}
      Public string PlayerClub {get;set;}  
    }
}