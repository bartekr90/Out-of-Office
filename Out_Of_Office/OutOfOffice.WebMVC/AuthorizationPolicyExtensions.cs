using OutOfOffice.Domain.Rules;

namespace OutOfOffice.WebMVC;

public static class AuthorizationPolicyExtensions
{
    public static IServiceCollection AddProjectControllerPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(nameof(ProjectRules.Read), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.HRManager), nameof(Role.ProjectManager));
            });
            
            options.AddPolicy(nameof(ProjectRules.Create), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.ProjectManager));
            });
            
            options.AddPolicy(nameof(ProjectRules.Deactivate), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.ProjectManager));
            });
            
            options.AddPolicy(nameof(ProjectRules.Update), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.ProjectManager));
            });
        });

        return services;
    }

    public static IServiceCollection AddLeaveRequestsControllerPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(nameof(LeaveRequestsRules.Read), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.HRManager), nameof(Role.ProjectManager), nameof(Role.Employee));
            });

            options.AddPolicy(nameof(LeaveRequestsRules.Create), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.Employee));
            });

            options.AddPolicy(nameof(LeaveRequestsRules.Update), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.Employee));
            });
            
            options.AddPolicy(nameof(LeaveRequestsRules.Delete), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.Employee));
            });

            options.AddPolicy(nameof(LeaveRequestsRules.Submit), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.Employee));
            });

            options.AddPolicy(nameof(LeaveRequestsRules.Cancel), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.Employee));
            });
        });

        return services;
    }
    public static IServiceCollection AddApprovalRequestsControllerPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(nameof(ApproveRequestsRules.Approve), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.HRManager), nameof(Role.ProjectManager));
            });

            options.AddPolicy(nameof(ApproveRequestsRules.Read), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.HRManager), nameof(Role.ProjectManager));
            });

            options.AddPolicy(nameof(ApproveRequestsRules.Reject), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.HRManager), nameof(Role.ProjectManager));
            });
            
        });

        return services;
    }

    public static IServiceCollection AddEmployeeControllerPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(nameof(EmployeeRules.Assign), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.ProjectManager));
            });

            options.AddPolicy(nameof(EmployeeRules.Read), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.ProjectManager), nameof(Role.HRManager));
            });

            options.AddPolicy(nameof(EmployeeRules.Create), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.HRManager));
            });

            options.AddPolicy(nameof(EmployeeRules.Update), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.HRManager));
            });

            options.AddPolicy(nameof(EmployeeRules.Deactivate), policy =>
            {
                policy.RequireRole(nameof(Role.Administrator), nameof(Role.HRManager));
            });

        });

        return services;
    }
}