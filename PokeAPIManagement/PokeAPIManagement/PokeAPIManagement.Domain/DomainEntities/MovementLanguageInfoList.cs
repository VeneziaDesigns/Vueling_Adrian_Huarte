using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIManagement.Domain.DomainEntities
{
    public class MovementLanguageInfoList
    {
        public List<MovementLanguageInfo> MovementLanguageInfo { get; set; }

        public string GetMovementNameByLanguageId(string languageId)
        {
            return MovementLanguageInfo.FirstOrDefault(languageInfo => languageInfo.LanguageName == languageId).MovementName;
        }
    }
}
