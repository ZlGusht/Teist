import { ConfigInterface } from './config.interface';

const Configuration = {
    routes: {
        questionnaire: {
            path: '/questionnaire'
        },
        tutorial: {
            path: '/tutorial'
        },
        survey: {
            path: '/survey'
        },
        home: {
            path: '/home'
        }
    },

    adminRoutes: {
        prefix: 'administrator',

        category: {
            path: '/category'
        },
        categoryGroup: {
            path: '/categoryGroup'
        },
        departament: {
            path: '/departament'
        },
        email: {
            path: '/email'
        },
        emailTemplate: {
            path: '/emailTemplate'
        },
        home: {
            path: '/home'
        },
        location: {
            path: '/location'
        },
        prospect: {
            path: '/prospect'
        },
        question: {
            path: '/question',
            pages: {
                all: 'all',
                create: 'create'
            }
        },
        questionnaire: {
            path: '/questionnaire'
        },
        questionnaireReport: {
            path: '/questionnaireReport'
        },
        role: {
            path: '/role'
        },
        survey: {
            path: '/survey'
        },
        feedback: {
            path: '/feedback'
        },
        urgency: {
            path: '/urgency'
        },
        user: {
            path: '/user'
        }
    },

    restApi: {
        prefix: '/api',
        question: {
            controller: '/question',
            actions: {
                all: '/all',
                get: '/{id}'
            }
        }
    },

    tokenName: 'auth_token'

};

export function getConfig(): ConfigInterface {
    const config = JSON.parse(JSON.stringify(Configuration));
    Object.keys(config.adminRoutes).forEach(key => {
        if (key !== 'prefix') {
            config.adminRoutes[key].path = config.adminRoutes.prefix + config.adminRoutes[key].path;
        }
    });

    Object.keys(config.restApi).forEach(key => {
        if (key !== 'prefix') {
            config.restApi[key].controller = config.restApi.prefix + config.restApi[key].controller;
        }
    });

    return config;
}
