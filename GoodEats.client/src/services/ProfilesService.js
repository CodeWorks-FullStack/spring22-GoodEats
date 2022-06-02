import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js"
import { reviewsService } from "./ReviewsService.js"

class ProfilesService {
  async getProfile(id) {
    const res = await api.get('api/profiles/' + id)
    AppState.profile = res.data
    await reviewsService.getReviewsByProfileId(id)
  }
}

export const profilesService = new ProfilesService()