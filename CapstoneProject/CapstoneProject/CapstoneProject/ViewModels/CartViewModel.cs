using System.ComponentModel.DataAnnotations;
using CapstoneProject.Models;
namespace CapstoneProject.ViewModels
{
    public class CartViewModel
    {
        public List<UserApplication> UserApplications { get; set; }
        public List<Item> Items { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<TransactionLineItem> TransactionLineItems { get; set; }
    }
}

/*Tables to update
 * 
 * Transactions
 *      TransactionID       (AUTO ID) >------------------------
 *      UserID              (FK to UserApplications)          |
 *      Date                Time of request                   |
 *                                                            |
 * TransactionLineItems                                       |
 *      TransactionID       (FK to Transactions) <-------------
 *      ItemsID             (FK to Items)
 *      Quantity            requested on page
 *      
 *Items
 *      Quantity            -= requested on page
*/