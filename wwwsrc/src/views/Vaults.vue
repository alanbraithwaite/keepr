<template>
  <div class="row d-flex justify-content-center">
    <div class="row col-12 d-flex justify-content-center">
      <form @submit.prevent="addVault" v-if="showAddVaultForm">
        <input type="text" placeholder="Name" v-model="newVault.name" required>
        <input type="textarea" placeholder="Description" v-model="newVault.description" required>
        <button data-toggle="tooltip" data-placement="bottom" title="addVault" type="submit"><i class="fas fa-plus"></i></button>
      </form>
    </div>

    <div class="row d-flex justify-content-center align-items-center" v-for="vault in vaults" :key="vault.id">
      <div class="col-12 card">
        <span class="name">
          <h2>{{vault.name}}</h2>
        </span>
        <span class="name">
          <h3>{{vault.description}}</h3>
        </span>
        <span class="name">
          <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">
            <h4>VIEW</h4>
          </router-link>
          <!-- <button @click="openVault(vault.id)"><i class="fas fa-plus"></i></button> -->
          <button @click="deleteVault(vault.id)"><i class="fas fa-trash"></i></button>
        </span>
      </div>
    </div>
  </div>



</template>

<script>
  export default {
    name: 'vaults',
    data() {
      return {
        showAddVaultForm: true,
        newVault: {
          name: '',
          description: ''
        }

      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults;
      }

    },

    mounted() {
      // get from store
      // this.$store.dispatch('getVaults');

    },

    methods: {
      deleteVault(vaultId) {
        this.$store.dispatch('deleteVault', vaultId)
      },

      addVault() {
        this.$store.dispatch('addVault', this.newVault)
        this.newVault = { Name: '', Description: '' }
      },
      // openVault(vaultId) {

      // }

    },
  }

</script>

<style>


</style>