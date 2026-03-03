(() => {
  const { createApp } = Vue;

  createApp({
    data() {
      return {
        companySize: 100,
        hasBudget: true,
        requestedDemo: false,
        region: 'Europe',
        industry: 'Retail',
        result: null,
        error: null
      };
    },
    methods: {
      async scoreLead() {
        this.error = null;
        this.result = null;

        const response = await fetch('/api/leads/score', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            companySize: this.companySize,
            hasBudget: this.hasBudget,
            requestedDemo: this.requestedDemo,
            region: this.region,
            industry: this.industry
          })
        });

        if (!response.ok) {
          this.error = 'Scoring failed.';
          return;
        }

        this.result = await response.json();
      }
    },
    template: `
      <div>
        <div class="row g-2">
          <div class="col-md-4">
            <label class="form-label">Company size</label>
            <input class="form-control" type="number" min="1" v-model.number="companySize" />
          </div>
          <div class="col-md-4">
            <label class="form-label">Region</label>
            <select class="form-select" v-model="region">
              <option>North America</option>
              <option>Europe</option>
              <option>Africa</option>
              <option>APAC</option>
            </select>
          </div>
          <div class="col-md-4">
            <label class="form-label">Industry</label>
            <select class="form-select" v-model="industry">
              <option>FinTech</option>
              <option>HealthTech</option>
              <option>Retail</option>
              <option>Manufacturing</option>
            </select>
          </div>
        </div>

        <div class="form-check mt-3">
          <input class="form-check-input" type="checkbox" id="budget" v-model="hasBudget" />
          <label class="form-check-label" for="budget">Has budget</label>
        </div>

        <div class="form-check">
          <input class="form-check-input" type="checkbox" id="demo" v-model="requestedDemo" />
          <label class="form-check-label" for="demo">Requested demo</label>
        </div>

        <button class="btn btn-dark mt-3" @click="scoreLead">Score lead</button>

        <div v-if="result" class="alert alert-success mt-3">
          Score: {{ result.score }} | Tier: {{ result.tier }}
        </div>

        <div v-if="error" class="alert alert-danger mt-3">{{ error }}</div>
      </div>
    `
  }).mount('#campaign-lab');
})();
