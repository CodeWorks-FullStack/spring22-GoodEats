import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RestaurantsService {
  async getAll() {
    const res = await api.get('api/restaurants')
    logger.log('[GET ALL RESTAURANTS]', res.data)
    AppState.restaurants = res.data
  }
}
export const restaurantsService = new RestaurantsService()