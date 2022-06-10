import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import Home from '../views/Home.vue';
import Authorization from '../views/Authorization.vue';
import AddCheck from '../views/AddCheck.vue';
import GetCheckByTagName from '../views/CheckByTag.vue';

Vue.use(VueRouter);

const routes: RouteConfig[] = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  {
    path: '/about/info/:id',
    name: 'About',
    props: true,
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue'),
  },

  {
    path: '/account/authorization',
    name: 'Aauthorization',
    component: Authorization,
  },
  {
    path: '/admin/addCheck',
    name: 'AddCheck',
    component: AddCheck,
  },

  {
    path: '/home/getCheckByTagName/:tagName',
    name: 'GetCheckByTagName',
    props: true,
    component: GetCheckByTagName,
  },

];

const router = new VueRouter({
  routes,
});

export default router;
