# PruebaCleanCode

- /api/Roulette/CreateRoulette

    Response:   
    {"id":"[id_roulette]"}

    
- /api/Roulette/OpenRoulette/{id}

    Response:   
    exitosa|denegada

    
- /api/Roulette/CloseRoulette/{id}

    Response:   
    {   
        "winValue":"[win_number]",  
        "winnerNumber": "[winners_by_number]",  
        "winnerColor": "[winners_by_color]",    
        "players": "[bettors_list]"    
    }

    
- /api/Roulette/CreateBet
    
    Request:  
    {   
        "RouletteId":"[id_roulette]",  
        "Number": "[number_to_win]",  
        "Color": "[color_to_win]",    
        "Amount": "[bet_amount]"    
    }
    
    Response:   
    exitosa|denegada
    
    
- /api/Roulette/ListRoulette

    Response:   
    [
      {   
        "RouletteId":"[id_roulette]",  
        "UserId":"[bet_user]",  
        "Number": "[number_to_win]",  
        "Color": "[color_to_win]",    
        "Amount": "[bet_amount]"      
      }, ...
    ]
