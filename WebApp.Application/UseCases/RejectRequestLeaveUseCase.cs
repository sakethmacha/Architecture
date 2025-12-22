using System;
using System.Collections.Generic;

using WebApp.Domain.Interfaces.Repositories;

namespace WebApp.Application.UseCases
{
    public class RejectRequestLeaveUseCase
    {
        private readonly ILeaveRequestRepository LeaveRepository;

        public RejectRequestLeaveUseCase(ILeaveRequestRepository leaveRepository)
        {
            LeaveRepository = leaveRepository;
        }

        public void Execute(int leaveRequestId)
        {
            // 1️⃣ Load aggregate
            var request = LeaveRepository.GetById(leaveRequestId);

            // 2️⃣ Domain rule
            request.Reject();

            // 3️⃣ Persist
            LeaveRepository.Save(request);
        }
    }
}