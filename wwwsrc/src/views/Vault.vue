<template>
  <div class="row  d-flex justify-content-center">
    <h1>{{activevault.name}}</h1>
    <router-link :to="{name: 'vaults'}">
      <h4> back to Vaults </h4>
    </router-link>
    <div class="row">
      <div class=" row col d-flex justify-content-center">
        <div class="">
        </div>

      </div>
      <div class="row col d-flex justify-content-center" v-for="keep in vaultkeeps">
        <div class=" card">
          <img :src="keep.img" height="150" width="200">
          <span class="name">{{keep.name}}</span>
          <span class="kept"><i class="far fa-thumbs-up"></i>Kept: {{keep.keeps}}</span>
          <span class="views"><i class="far fa-eye"></i>Views: {{keep.views}} </span>
          <button @click="removeFromVault(keep.id)"><i>remove</i></button>
          <router-link :to="{name: 'vaultcurrentkeep', params: {keepId: keep.id, vaultId:activevault.id}}">
            <h4>VIEW</h4>
          </router-link>

        </div>
      </div>

    </div>
  </div>
</template>

<script>
  export default {
    name: 'vault',
    data() {
      return {

      }
    },

    mounted() {
      this.$store.dispatch('getVaultKeeps', this.$route.params.vaultId)

    },
    computed: {
      vaultkeeps(keepId) {
        return this.$store.state.vaultkeeps;
      },
      activevault() {
        return this.$store.state.vaults.find(v => v.id == this.$route.params.vaultId);
      }


    },
    methods: {

      removeFromVault(keepId) {
        let payload = { keepId: keepId, vaultId: this.activevault.id };
        debugger
        this.$store.dispatch("removeFromVault", payload);
      }
    },

    // props: ['vaultId']

  }

</script>

<style>
  h1 {
    color: azure;
  }

  h4 {
    border-color: black;
    color: azure;
  }
</style>