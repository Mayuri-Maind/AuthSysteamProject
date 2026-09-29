#  #code start
#  #def is used to define/create function
#  #calculate Risk is the function name
#  #entitlment is the input/parameter pass to the function
# def calculate_rist(entitlement):
#     if entitlement > 50:
#         return "High"

#     #elif means else if
#     # it checks this conditon only when the previous id conditon is false
#     elif entitlement > 20:
#         return "Medium"

#     else:
#         return "Low"  

# Risk = calculate_rist(80)       
# print(Risk)

#pyhton code
#Import RandomForestClassifer From scikit-Learn.
#Random forest is the machine learning algorithm we are using
from sklearn.ensemble import RandomForestClassifier

# STEP 1: TRAINING DATA
# ============================================================

# X contains the input/features used by the AI model.
#
# Each row represents one user.
#
# The 4 values in each row mean:
#
# 1. Total Entitlements
# 2. Privileged Access
# 3. Sensitive Application Access
# 4. Expired Access
#
# Example:
# [70, 1, 1, 0]
#
# means:
# Total Entitlements = 70
# Privileged Access = Yes (1)
# Sensitive Application Access = Yes (1)
# Expired Access = No (0)

x =[
    [10, 0, 0, 0],
    [20, 0, 0, 0],
    [30, 0, 0, 0],
    [40, 0, 1, 0],
    [50, 0, 1, 0],
    [60, 1, 0, 0],
    [70, 1, 1, 0],
    [80, 1, 1, 0],
    [90, 1, 1, 1],
    [100, 1, 1, 1],
    [120, 1, 1, 1],
    [150, 1, 1, 1]
]



# ============================================================
# STEP 2: OUTPUT / ANSWER DATA
# ============================================================

# y contains the answer for each user.
#
# 0 = Low Risk
# 1 = High Risk
#
# The position must match the X data.
#
# For example:
# X[0] = [10, 0, 0, 0]
# y[0] = 0
#
# So the model learns:
# User with these features -> Low Risk

y = [
    0,  # User 1  -> Low Risk
    0,  # User 2  -> Low Risk
    0,  # User 3  -> Low Risk
    0,  # User 4  -> Low Risk
    0,  # User 5  -> Low Risk
    0,  # User 6  -> Low Risk
    1,  # User 7  -> High Risk
    1,  # User 8  -> High Risk
    1,  # User 9  -> High Risk
    1,  # User 10 -> High Risk
    1,  # User 11 -> High Risk
    1   # User 12 -> High Risk
]



# ============================================================
# STEP 3: CREATE THE MACHINE LEARNING MODEL
# ============================================================

# Create a Random Forest model.
#
# n_estimators=100 means:
# The Random Forest will create 100 decision trees.
#
# random_state=42 makes the result consistent
# when we run the program multiple times.


model = RandomForestClassifer(
    n_estimators=100,
    random_state=42
)




# ============================================================
# STEP 4: TRAIN THE MODEL
# ============================================================

# fit() means TRAIN the Machine Learning model.
#
# X = input/features
# y = expected answer
#
# The model looks at X and y and learns patterns.

model.fit(X,y)


# ============================================================
# STEP 5: GIVE A NEW USER TO THE MODEL
# ============================================================

# Now we have a NEW user.
#
# This user is not directly giving us the risk.
# We give only the user's access information.
#
# Values:
#
# Total Entitlements = 120
# Privileged Access = Yes
# Sensitive Application Access = Yes
# Expired Access = Yes

new_user[
    [120,1,1,1]
]

# ============================================================
# STEP 6: PREDICT LOW OR HIGH RISK
# ============================================================

# predict() gives the predicted class.
#
# 0 = Low Risk
# 1 = High Risk

prediction = model.predict(new_user)

# Print the prediction returned by the model.
#
# prediction[0] gets the first result from the list.

print("Prediction : ", prediction[0])

# ============================================================
# STEP 7: GET PROBABILITY
# ============================================================

# predict_proba() gives the probability for each class.
#
# Example:
#
# [0.10, 0.90]
#
# means:
#
# Low Risk  = 10%
# High Risk = 90%

probability = model.predict_proba(new_user)

# Get the probability of High Risk.
#
# probabilities[0] = first user's probabilities
#
# probabilities[0][1] = probability of class 1
#
# class 1 means High Risk.

high_risk_probability = probabilities[0][1]

# ============================================================
# STEP 8: CONVERT PROBABILITY INTO RISK SCORE
# ============================================================

# Probability is between 0 and 1.
#
# Example:
# 0.85 = 85%
#
# Multiply by 100 to get a score between 0 and 100.
risk_score = high_risk_probability * 100


# ============================================================
# STEP 9: DETERMINE RISK LEVEL
# ============================================================

# If risk score is 70 or above,
# we consider it High Risk.
if risk_score >= 70:
    risk_level = "High Risk"

# If risk score is 40 or above but less than 70,
# we consider it Medium Risk.

elif risk_score >= 40:
    risk_level = "Medium Risk"


# If risk score is below 40,
# we consider it Low Risk.

else:
    risk_level = "Low Risk"


# ============================================================
# STEP 10: DISPLAY FINAL RESULT
# ============================================================

print("--------------------------------")
print("IGA USER RISK RESULT")
print("--------------------------------")


# Display the risk score.
#
# round(..., 2) means keep only 2 decimal places.

print("Risk Score:", round(risk_score, 2))


# Display Low / Medium / High Risk.

print("Risk Level:", risk_level)    