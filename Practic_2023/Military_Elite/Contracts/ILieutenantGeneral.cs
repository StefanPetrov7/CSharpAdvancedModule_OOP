using Military_Elite.Models;
namespace Military_Elite.Contracts
{
    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<Private> Privates { get; }
    }
}

