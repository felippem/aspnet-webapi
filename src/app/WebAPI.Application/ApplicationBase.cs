using WebAPI.Infra.Data.DataContext.UnitOfWork;

namespace WebAPI.Application
{
    public class ApplicationBase
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        public ApplicationBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Behaviors

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

        #endregion
    }
}
