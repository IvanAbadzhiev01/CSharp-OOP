using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;
        private List<string> validSize = new List<string>()
        {
            "Small",
            "Middle",
            "Large"
        };
        public Controller()
        {
            booths = new BoothRepository();
        }


        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (!validSize.Contains(size))
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }


            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail;
            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size) != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }
            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName) != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double curentBild = booth.CurrentBill;
            booth.ChangeStatus();
            booth.Charge();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {curentBild:f2} lv").AppendLine($"Booth {boothId} is now available!");
            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> ordaredBooths = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople).OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).ToList();

            if (ordaredBooths.Count == 0)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            else
            {
                ordaredBooths[0].ChangeStatus();
                return string.Format(OutputMessages.BoothReservedSuccessfully, ordaredBooths[0].BoothId, countOfPeople);
            }
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderArgs = order.Split("/");
            string itemTypeName = orderArgs[0];

            if (!(itemTypeName == nameof(Gingerbread) || itemTypeName == nameof(Stolen) || itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation)))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            string itemName = orderArgs[1];
            IDelicacy delicacy1 = booth.DelicacyMenu.Models.FirstOrDefault(m => m.Name == itemName);
            ICocktail cocktail1 = booth.CocktailMenu.Models.FirstOrDefault(m => m.Name == itemName);
            if (delicacy1 == null && cocktail1 == null)
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }
            //TryOrder


            bool isCoctail = itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation);
            string size = null;
            int orderPices = int.Parse(orderArgs[2]);
            if (isCoctail)
            {
                size = orderArgs[3];
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size && itemTypeName == c.GetType().Name);
                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }
                booth.UpdateCurrentBill(cocktail.Price * orderPices);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderPices, itemName);
            }
            else
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName && d.GetType().Name == itemTypeName);
                if (delicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
                booth.UpdateCurrentBill(delicacy.Price * orderPices);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderPices, itemName);
            }
        }

    }



}

