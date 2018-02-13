using Expedia.CodingExercise.DataType;
using Expedia.CodingExercise.DataType.Models;
using Expedia.CodingExercise.DataType.Requests.HotelsOffering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.CodingExercise.BusinessLogic.Interface
{
    public interface IHotelsOffering
    {
        ActivityResult GetOffers(HotelsOffersFilter filter, HotelsOffersSorting sorting);
    }
}
