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
// @ts-ignore
import VaultCurrentKeep from './views/VaultCurrentKeep.vue'
// @ts-ignore
import HomeCurrentKeep from './views/HomeCurrentKeep.vue'

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
      path: '/vault/:vaultId',
      name: 'vault',
      props: true,
      component: Vault
    },
    {
      path: '/currentkeep/:keepId',
      name: 'currentkeep',
      props: true,
      component: CurrentKeep
    },
    {
      path: '/vaultcurrentkeep/:keepId/:vaultId',
      name: 'vaultcurrentkeep',
      props: true,
      component: VaultCurrentKeep
    },
    {
      path: '/homecurrentkeep/:keepId',
      name: 'homecurrentkeep',
      props: true,
      component: HomeCurrentKeep
    }

  ]
})
