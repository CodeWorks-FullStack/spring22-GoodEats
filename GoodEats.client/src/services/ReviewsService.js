import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ReviewsService {
  async getReviews(id) {
    const res = await api.get(`api/restaurants/${id}/reviews`)
    logger.log("[RESTAURANT REVS]", res.data)
    AppState.restaurantReviews = res.data
  }

  async getReviewsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/reviews`)
    logger.log("[Profile REVS]", res.data)
    AppState.profileReviews = res.data
  }

}

export const reviewsService = new ReviewsService()