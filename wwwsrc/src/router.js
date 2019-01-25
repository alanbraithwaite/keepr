import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'
// @ts-ignore
import Keeps from './views/Keeps.vue'
// @ts-ignore
import Vaults from './views/Vaults.vue'
// @ts-ignore
import Vault from './views/Vault.vue'
// @ts-ignore
import CurrentKeep from './views/CurrentKeep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/keeps',
      name: 'keeps',
      component: Keeps
    },
    {
      path: '/vaults',
      name: 'vaults',
      component: Vaults
    },
    {
      path: '/vault',
      name: 'vault',
      component: Vault
    },
    {
      path: '/currentkeep/:keepId',
      name: 'currentkeep',
      props: true,
      component: CurrentKeep
    }

  ]
})
