using WebAPI.Data.DataContext.UnitOfWork;

namespace WebAPI.Application
{
    public class ApplicationBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Begin()
        {
            _unitOfWork.Begin();
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Rollback()
        {
            _unitOfWork.Rollback(); 
        }
    }
}
