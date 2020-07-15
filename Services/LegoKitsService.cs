using System;
using legomylego.Models;
using legomylego.Reopsitories;
namespace legomylego.Services
{
  public class LegoKitsService
  {
    private readonly LegoKitRepository _repo;
    public LegoKitsService(LegoKitRepository repo)
    {
      _repo = repo;
    }

    internal LegoKitHelper Get(int id)
    {
      LegoKitHelper found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("invalid id mi amigo");
      }
      return found;
    }

    internal DTOLegoKit Create(DTOLegoKit newDTOLegoKit)
    {
      int id = _repo.Create(newDTOLegoKit);
      newDTOLegoKit.Id = id;
      return newDTOLegoKit;
    }

    internal DTOLegoKit Delete(int id)
    {
      DTOLegoKit found = Get(id);
      _repo.Delete(id);
      return found;
    }
  }
}