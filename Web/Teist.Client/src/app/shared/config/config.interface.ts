import { RouteConfig } from './route-config.interface';
import { ApiEndpoint } from './api.endpoint.interface';

export interface ConfigInterface {
    routes: {
        questionnaire: RouteConfig,
        tutorial: RouteConfig,
        survey: RouteConfig,
        home: RouteConfig
    };

    adminRoutes: {
        prefix: string,

        category: RouteConfig,
        categoryGroup: RouteConfig,
        departament: RouteConfig,
        email: RouteConfig,
        emailTemplate: RouteConfig,
        home: RouteConfig,
        location: RouteConfig,
        prospect: RouteConfig,
        question: RouteConfig,
        questionnaire: RouteConfig,
        questionnaireReport: RouteConfig,
        role: RouteConfig,
        survey: RouteConfig,
        feedback: RouteConfig,
        urgency: RouteConfig,
        user: RouteConfig
    };

    restApi: {
        prefix: string,
        question: ApiEndpoint
    };

    tokenName: string;
}
