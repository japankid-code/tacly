import { createRouter, createWebHashHistory } from "vue-router";
import Home from "../views/Home.vue";
const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/login",
        name: "Login",
        // route level code-splitting
        // this generates a separate chunk (login.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "login" */ "../views/Login.vue"),
    },
    {
        path: "/signup",
        name: "Signup",
        // route level code-splitting
        // this generates a separate chunk (signup.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "signup" */ "../views/Signup.vue"),
    },
    {
        path: "/profile",
        name: "Profile",
        component: () => import(/* webpackChunkName: "profile" */ "../views/Profile.vue"),
    },
];
const router = createRouter({
    history: createWebHashHistory(),
    routes,
});
export default router;
//# sourceMappingURL=index.js.map