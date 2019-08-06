export interface RouteConfig {
/** The path of the route. */
readonly path: string;
/** List of sub pages for the route. */
readonly pages?: any;
/** Parameter names for the configuration. */
readonly params?: any;
}
