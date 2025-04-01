using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillsManager : ISkillsService
    {
        private readonly ISkillsDal _skillsDal;

        public SkillsManager(ISkillsDal skillsDal)
        {
            _skillsDal = skillsDal;
        }

        public List<Skill> TGetSkills()
        {
            return _skillsDal.List(); 
        }
    }
}
