/*
 * File name:               CardClass.cs
 * Author:                  Johann Bekker
 * Created:                 20/08/2016
 * Operating System:        Windows 7 
 * Version:                 Home Basic
 * Description:             The following code defines which attributes a new card will have on creation.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackProject
{
    public class CardClass
    {
        public int numberOfCard { set; get; }
        public string suit { set; get; }
        public int rank { set; get; }

        // When new card is created
        public CardClass()
        {
            rank = -1;
            suit = "blank";
            numberOfCard = -1;
        }
    } 
}
